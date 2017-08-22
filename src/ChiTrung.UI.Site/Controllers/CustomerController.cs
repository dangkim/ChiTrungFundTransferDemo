using System;
using ChiTrung.Application.Interfaces;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChiTrung.UI.Site.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IBankAppService _bankAppService;
        private readonly IAccountAppService _accountAppService;
        private readonly IAtmAppService _atmAppService;
        private readonly IDepositAppService _depositAppService;
        private readonly IWithdrawalAppService _withdrawalAppService;

        public CustomerController(ICustomerAppService customerAppService,
                                    IBankAppService bankAppService,
                                    IAccountAppService accountAppService,
                                    IAtmAppService atmAppService,
                                    IDepositAppService depositAppService,
                                    IWithdrawalAppService withdrawalAppService,
                                    INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
            _bankAppService = bankAppService;
            _accountAppService = accountAppService;
            _atmAppService = atmAppService;
            _depositAppService = depositAppService;
            _withdrawalAppService = withdrawalAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/list-all")]
        public IActionResult Index()
        {
            ViewData["Customers"] = _customerAppService.GetAll();
            ViewData["Banks"] = _bankAppService.GetAll();
            ViewData["Accounts"] = _accountAppService.GetAll();
            ViewData["Atms"] = _atmAppService.GetAll();
            ViewData["Deposit"] = _depositAppService.GetAll();
            ViewData["Withdrawal"] = _withdrawalAppService.GetAll();
            return View();
            //return View(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management/customer-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            _customerAppService.Register(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(customerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newbank")]
        public IActionResult CreateBank()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newbank")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBank(BankViewModel bankViewModel)
        {
            if (!ModelState.IsValid) return View(bankViewModel);
            _bankAppService.AddNewBank(bankViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Bank Added!";

            return View(bankViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newAccount")]
        public IActionResult CreateAccount()
        {
            ViewData["Customers"] = new SelectList(_customerAppService.GetAll(), "Id", "Name");
            ViewData["Banks"] = new SelectList(_bankAppService.GetAll(), "BankCode", "BankName");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newAccount")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid) return View(accountViewModel);
            _accountAppService.AddNewAccount(accountViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Account Added!";

            ViewData["Customers"] = new SelectList(_customerAppService.GetAll(), "Id", "Name");
            ViewData["Banks"] = new SelectList(_bankAppService.GetAll(), "BankCode", "BankName");

            return View(accountViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newAtm")]
        public IActionResult CreateAtm()
        {
            ViewData["Banks"] = new SelectList(_bankAppService.GetAll(), "BankCode", "BankName");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/add-newAtm")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAtm(AtmViewModel atmViewModel)
        {
            if (!ModelState.IsValid) return View(atmViewModel);
            _atmAppService.AddNewAtm(atmViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Atm Added!";

            ViewData["Banks"] = new SelectList(_bankAppService.GetAll(), "BankCode", "BankName");

            return View(atmViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/deposit")]
        public IActionResult Deposit()
        {
            ViewData["Customers"] = new SelectList(_customerAppService.GetAll(), "Id", "Name");
            ViewData["Accounts"] = new SelectList(_accountAppService.GetAll(), "AccCode", "AccCode");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/deposit")]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(DepositViewModel depositViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(depositViewModel);
            }

            _depositAppService.DepositMoney(depositViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "deposit successful!";

            ViewData["Customers"] = new SelectList(_customerAppService.GetAll(), "Id", "Name");
            ViewData["Accounts"] = new SelectList(_accountAppService.GetAll(), "AccCode", "AccCode");

            return View(depositViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/withdrawal")]
        public IActionResult Withdrawal()
        {
            ViewData["Accounts"] = new SelectList(_accountAppService.GetAll(), "AccCode", "AccCode");
            ViewData["Atms"] = new SelectList(_atmAppService.GetAll(), "AtmCode", "AtmCode");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/withdrawal")]
        [ValidateAntiForgeryToken]
        public IActionResult Withdrawal(WithdrawalViewModel withdrawalViewModel)
        {
            withdrawalViewModel.WitCode = Guid.NewGuid().ToString();

            if (!ModelState.IsValid) return View(withdrawalViewModel);
            _withdrawalAppService.WithdrawalAtm(withdrawalViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "withdrawal successful!";

            ViewData["Accounts"] = new SelectList(_accountAppService.GetAll(), "AccCode", "AccCode");
            ViewData["Atms"] = new SelectList(_atmAppService.GetAll(), "AtmCode", "AtmCode");

            return View(withdrawalViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/fundTransfer")]
        public IActionResult FundTransfer()
        {
            ViewData["Accounts"] = new SelectList(_accountAppService.GetAll(), "AccCode", "AccCode");
            ViewData["Atms"] = new SelectList(_atmAppService.GetAll(), "AtmCode", "AtmCode");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/fundTransfer")]
        [ValidateAntiForgeryToken]
        public IActionResult FundTransfer(FundTransferViewModel fundTransferViewModel)
        {
            var account = _accountAppService.GetByAccCode(fundTransferViewModel.AccCode);
            fundTransferViewModel.WitCode = Guid.NewGuid().ToString();

            if (account != null)
            {
                fundTransferViewModel.CusId = account.CusId;
            }

            if (!ModelState.IsValid)
            {
                return View(fundTransferViewModel);
            }

            _withdrawalAppService.FundTransfer(fundTransferViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "transfer successful!";

            return View(fundTransferViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCustomerData")]
        [Route("customer-management/edit-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(customerViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer-management/remove-customer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _customerAppService.Remove(id);

            if (!IsValidOperation()) return View(_customerAppService.GetById(id));

            ViewBag.Sucesso = "Customer Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("customer-management/customer-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var customerHistoryData = _customerAppService.GetAllHistory(id);
            return Json(customerHistoryData);
        }
    }
}
