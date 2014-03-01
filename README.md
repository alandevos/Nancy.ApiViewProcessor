Nancy.ApiViewProcessor
===================

An example of how you can use [Nancy's content negotiation](https://github.com/NancyFx/Nancy/wiki/Content-Negotiation) - using IResponseProcessor and response Negotiator to to send a customized "API version" of a view.

## How to use

`ViewApiProcessor : IResponseProcessor` (which is auto-discovered at runtime) is currently wired to respond to a request with an `Accept: text/plain` header.  It can be changed to anything.
```C#
bool matchingContentType = requestedMediaRange.Matches("text/plain");
```
When it processes the response, it adds a ViewBag property to let the view know this is an 'api' request.
```C#
context.ViewBag.RequestType = "api";
```
Then, the view can use that information to customize the view.  For instance, by setting `Layout = null` and returning a partial:
```C#
string layout = "Views/Shared/_MainLayout.cshtml";

if (ViewBag.RequestType == "api")
{
	layout = null;
}

Layout = layout;
```
Finally, in the module, rather than `return View["Index"]`, we have to return `Negotiator`.
```C#
return Negotiate.WithView("Index");
```
The [Negotiator](https://github.com/NancyFx/Nancy/wiki/Content-Negotiation) has several other methods that can be used to further customize the response.
