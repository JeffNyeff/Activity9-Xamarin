using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            //Get All Persons
            var listItems = await App.SQLiteDb.GetItemsAsync();
            if(listItems!=null)
            {
                lstItems.ItemsSource = listItems;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItem.Text))
            {
                ItemList itemList = new ItemList()
                {
                    Item = txtItem.Text
                };

                //Add New Item
                await App.SQLiteDb.SaveItemAsync(itemList);
                txtItem.Text = string.Empty;
                await DisplayAlert("Success", "Item added Successfully", "OK");
                //Get All items
                var listofitems = await App.SQLiteDb.GetItemsAsync();
                if (listofitems != null)
                {
                    lstItems.ItemsSource = listofitems;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter Item!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemId.Text))
            {
                //Get Person
                var item = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtItemId.Text));
                if(item!=null)
                {
                    txtItem.Text = item.Item;
                    await DisplayAlert("Success","Added Item: "+ item.Item, "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter Item", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemId.Text))
            {
                ItemList itemList = new ItemList()
                {
                    ItemID=Convert.ToInt32(txtItemId.Text),
                    Item = txtItem.Text
                };

                //Update item
                await App.SQLiteDb.SaveItemAsync(itemList);

                txtItemId.Text = string.Empty;
                txtItem.Text = string.Empty;
                await DisplayAlert("Success", "Item Updated Successfully", "OK");
                //Get All items
                var List = await App.SQLiteDb.GetItemsAsync();
                if (List != null)
                {
                    lstItems.ItemsSource = List;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter ItemID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemId.Text))
            {
                //Get Item
                var item = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtItemId.Text));
                if (item != null)
                {
                    //Delete item
                    await App.SQLiteDb.DeleteItemAsync(item);
                    txtItemId.Text = string.Empty;
                    await DisplayAlert("Success", "Item Deleted", "OK");
                    
                    //Get All items
                    var itemList = await App.SQLiteDb.GetItemsAsync();
                    if (itemList != null)
                    {
                        lstItems.ItemsSource = itemList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter ItemID", "OK");
            }
        }
    }
}
