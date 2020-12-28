using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetricUnitConverter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conversion_ContentPage : ContentPage
    {
        private IList<ContactMethod> _contactMethods;
        public Conversion_ContentPage()
        {
            InitializeComponent();

            _contactMethods = GetContactMethods();

            foreach (var method in _contactMethods)contactMethotds.Items.Add(method.Name);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contactMethotds.Items[contactMethotds.SelectedIndex];
            var contactMethod = _contactMethods.Single(cm => cm.Name == name);
            DisplayAlert("Selection", name, "OK");
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod{Id=1, Name="Phone"},
                new ContactMethod{Id=2, Name="Email"}
            };
        }
    }

    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}