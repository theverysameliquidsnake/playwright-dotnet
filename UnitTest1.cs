using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[TestFixture]
public class PromTest : PageTest {

    private const string PromUrl = "https://prom.ua";
    private const string SearchQuery = "ecoflow delta 2";

    [Test]
    public async Task SearchAndAddToShoppingCart() {
        var promPage = new PromPage(Page);
        
        // Search for a product
        await promPage.GotoAsync(PromUrl);      
        await promPage.SearchProduct(SearchQuery);

        await promPage.AssertFirstResultHasSearchString(SearchQuery);
        
        // Click first result
        await promPage.ClickFirstSearchResult();
        
        await promPage.AssertProductTitleHasSearchString(SearchQuery);

        // Add to cart
        await promPage.ClickBuyButton();  
        await promPage.ClickShoppingCartIcon();

        await promPage.AssertShoppingCartItemHasSearchString(SearchQuery);
    }
}
