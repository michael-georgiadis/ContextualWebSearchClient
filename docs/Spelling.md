# Spelling

Spelling is much simpler, than the search. The parameters for the request are just text. The way to call it is simple:

```csharp
// Same for SpellCheck
var autoCompleteResult = await contextualClient.AutoComplete("Hello, there");
```

The retun type of Autocomplete is List<string> and in SpellCheck is just the corrected text.  