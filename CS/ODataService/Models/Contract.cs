using DevExpress.Xpo;
using System;
using ODataService.ValueConverters;

namespace ODataService.Models
{
    [Persistent("Contracts")]
    public class Contract : BaseDocument
    {

        public Contract(Session session) : base(session) { }
        public Contract() { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            DateInsert = DateTime.Now;
        }

        string fNumber;
        public string Number
        {
            get { return fNumber; }
            set { SetPropertyValue<string>(nameof(Number), ref fNumber, value); }
        }

        Customer fCustomerID;
        [Size(5)]
        [Association(@"ContractsReferencesCustomers")]
        [Persistent("CustomerID")]
        public Customer Customer
        {
            get { return fCustomerID; }
            set { SetPropertyValue<Customer>(nameof(Customer), ref fCustomerID, value); }
        }

        #region DateInsert (DateTime)
        /// <summary>
        /// TODO: Doplnit komentář k vlastnosti <see cref="DateInsert" />
        /// </summary>
        [ValueConverter(typeof(GeneralDateTimeConverter))]
        public DateTime DateInsert
        {
            get => dateInsert;
            set => SetPropertyValue(StartDatePropertyName, ref dateInsert, value);
        }

        private DateTime dateInsert;

        public const string StartDatePropertyName = nameof(DateInsert);
        #endregion DateInsert (DateTime)



    }
}