# ContextualWebSearch C# Client

<div align="justify">
    ![alt text](logo.png "Logo")
</div>

I wanted to use the free [ContextualWebSearch API](https://contextualweb.io/) and I realized that C# had no apparent client. If there is and I missed it... **Oh well**.  

The API consists of 5 types of functionalities and naturally, so does my client.  

* Auto Complete
* Image Search
* News Search
* Spell Check
* Web Search

It also supports Microsoft's Dependency Injection. It adds the clients as Singleton by default, but the interfaces and classes are provided so you can implement Transients and Scoped's, if you think that it suits your use-case better.

## More Information

The folder Docs contains all you need to know about the library.