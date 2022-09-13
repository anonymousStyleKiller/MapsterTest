using Microsoft.AspNetCore.Components;

namespace MapsterTest.WebUI.Shared;

public partial class Header
{
    [Parameter]
    public List<Cart> CartItem { get; set; }
    public List<Category> ListCategory;
    public float total;
    public int totalItem;
    public string searchActive;
    protected override void OnInitialized()
    {
        GetCart();
        ListCategory = new List<Category>();
    }

    public void GetCart()
    {
        CartItem = new List<Cart>();
    }

    public async Task RemoveFromCart(int id)
    {

        GetCart();
        //StateHasChanged();

    }

    public void OpenSearch()
    {
        if (searchActive is null)
        {
            searchActive = "active";
        }
        else
        {
            searchActive = null;
        }
    }
}

public class Cart
{
}

public class Category
{
}