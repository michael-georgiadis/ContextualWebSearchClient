# Search

Generally, with this API you can choose among 3 types of searches

* Image Search
* Web Search
* News Search

Naturally with this API Client you can do all of those types, too. Their optional parameters are a little bit different, though. 

## How do I use it?

Fist you'll need the client
```csharp
var contextualClient = new ContextualWebSearchClient(YOUR_API_KEY);
```

And then in every search you have 3 choices. If you want to search with a simple string you can do it like this:  
```csharp
// This is the same with every type of search. NewsSearch is just used for examole here
var response = await contextualClient.NewsSearch("your query here");
```

If you want something more custom that the API can provide you can use the below parameters:  
  
To be more specific, the required paramaters for the search are the same in every type of search and they follow this model.

```csharp

public class SearchParameters 
{
    public string Query { get; set; }

    public int PageNumber { get; set; } = 1;

    private int PageSize { get; set; } = 10;

    public bool AutoCorrect { get; set; } = true;
}
```

I have put some default values there in every parameter except from query. For that reason when you create a new SearchParameter object you'll have to pass query via the constructor.

```csharp
var searchParameters = new SearchParameters("Some Query")
                       {
                           // Some custom values or none. Depending what you need.
                       }
```

Also PageSize cannot pass over 50, so I implemented a custom setter, so if you do make the mistake of going over 50 it will throw an Exception.  
  
For the optional parameters of the search though, things are a little bit different.  
For the NewsSearch the optional parameters are of form:  
```csharp
public class NewsOptionalParameters
{
    public bool? SafeSearch { get; set; }

    public bool? WithThumbnails { get; set; }

    public DateTime? FromPublishedDate { get; set; }

    public DateTime? ToPublishedDate { get; set; }
}
```

For the Web and Image Searches the optional parameters are of form:  
```csharp
public class WebAndImageOptionalParameters
{
    public bool SafeSearch { get; set; }
}
```

## Response
The responses are the same as the API specification. I've added a Status property in the responses to indicate if it was successful or not. If the request is unsucessful because of the query it WILL throw an exception. Please raise an issue if this happens, so I can look into it.