namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{

    private readonly Auth0Provider _auth0Provider;
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(Auth0Provider auth0Provider, IngredientsService ingredientsService)
    {
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

            ingredientData.CreatorId = userInfo.Id;

            Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
            return Ok(ingredient);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{ingredientId}")]
    public ActionResult<Ingredient> GetIngredientById(int ingredientId)
    {
        try
        {
            Ingredient ingredient = _ingredientsService.GetIngredientById(ingredientId);
            return Ok(ingredient);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{ingredientId}")]

    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _ingredientsService.DeleteIngredient(ingredientId, userId);
            return Ok(message);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}