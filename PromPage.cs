using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightTests;

public class PromPage {

    private readonly IPage page;

    public PromPage(IPage page) {
        this.page = page;
    }

    private ILocator SearchBar {
        get { return this.page.GetByPlaceholder("Я шукаю..."); }
    }

    private ILocator SearchButton {
        get { return this.page.Locator("[data-qaid='search_btn']"); }
    }

    private ILocator FirstSearchResult {
        get { return this.page.Locator("[data-qaid='product_link']").First; }
    }

    private ILocator ProductTitle {
        get { return this.page.Locator("[data-qaid='product_name']"); }
    }

    private ILocator BuyButton {
        get { return this.page.Locator("[data-qaid='buy-button']"); }
    }

    private ILocator ShoppingCartIcon {
        get { return this.page.Locator("[data-qaid='shopping_cart']"); }
    }

    private ILocator ShoppingCartItem {
        get { return this.page.Locator("[data-qaid='product_link']").First; }
    }

    public async Task GotoAsync(string url) {
        await this.page.GotoAsync(url, new() { WaitUntil = WaitUntilState.NetworkIdle });
    }

    public async Task SearchProduct(string searchString) {
        await SearchBar.PressSequentiallyAsync(searchString, new() { Delay = 150 });
        await Task.WhenAll(
            this.page.WaitForLoadStateAsync(LoadState.NetworkIdle),
            SearchButton.ClickAsync()
        );
    }

    public async Task AssertFirstResultHasSearchString(string searchString) {
        await Expect(FirstSearchResult).ToContainTextAsync(searchString, new() { IgnoreCase = true });
    }

    public async Task ClickFirstSearchResult() {
        await FirstSearchResult.ClickAsync();
    }

    public async Task AssertProductTitleHasSearchString(string searchString) {
        await Expect(ProductTitle).ToContainTextAsync(searchString, new() { IgnoreCase = true });
    }

    public async Task ClickBuyButton() {
        await BuyButton.ClickAsync();
        await Expect(BuyButton).ToContainTextAsync("До кошика", new() { Timeout = 5000 });
    }

    public async Task ClickShoppingCartIcon() {
        await ShoppingCartIcon.ClickAsync();
        await Expect(ShoppingCartItem).ToBeVisibleAsync(new() { Timeout = 5000 });
    }

    public async Task AssertShoppingCartItemHasSearchString(string searchString) {
        await Expect(ShoppingCartItem).ToContainTextAsync(searchString, new() { IgnoreCase = true });
    }
}