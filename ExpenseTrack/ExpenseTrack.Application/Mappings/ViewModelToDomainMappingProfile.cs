using AutoMapper;
using ExpenseTrack.Application.ViewModels;
using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CurrencyViewModel, Currency>();
            CreateMap<ExchangeRateViewModel, ExchangeRate>();
            CreateMap<ExpenseCategoryViewModel, ExpenseCategory>();
            CreateMap<ExpenseViewModel, Expense>();
            CreateMap<ReceiptViewModel, Receipt>();
        }
    }
}
