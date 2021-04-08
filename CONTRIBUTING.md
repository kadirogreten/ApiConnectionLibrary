Example using:

ApiConnectionLibrary.ConnectApiModel model = new ApiConnectionLibrary.ConnectApiModel
{
UrlEndPoint = "url endpoint",
Parameters = new
{
// parameters
}
};
var result = await ApiConnectionLibrary.ApiConnectionHelper<object>.PostAsync(model);
//or

var result = await ApiConnectionLibrary.ApiConnectionHelper<object>.GetAsync(urlendpoint,schema,authorizationToken);
