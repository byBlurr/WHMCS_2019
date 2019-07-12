# WHMCS_2019
WHMCS_2019 is an updated version of [WHMCS_API by PedroCavaleiro.](https://github.com/PedroCavaleiro/whmcs-api)

## Contents
* [Overview](#overview)
* [Supported Functions](#supported-functions)
* [Installation](#installation)
* [Example](#example)
* [Contribution](#contribution)
* [Unsupported Uses](#unsupported-uses)

---------------------------------------------------------------------------------------
## Overview
This is an library to comunicate with the WHMCS API.

## Supported Functions
A guide of all supported functions will be available once the package is published.

## Installation
A guide on installing will be available once the package is published.

## Example
```csharp
namespace YOUR_APP
{
    public class YOUR_CLASS
    {
        private int GetClientsCount()
        {
            int count = -1;
            string username = "WHMCS_USERNAME";
            string password = "WHMCS_PASSWORD";
            string accessKey = "WHNMCS_ACCESS_KEY";
            string whmcsUrl = "WHMCS_USERFRONTEND_URL"; //ex: https://example.com/client
            try
            {
                API api = new API(username, password, accessKey, whmcsUrl);
                count =  api.GetClients(0, 100);
            }
            catch (Exception e)
            {
                Console.WriteLine("API Error: {0}", e.Message);
            }
            return count;
        }
    }
}
```

## Contribution
You can fork this project and create pull requests. Please follow the same code presentation and comment everything you do.
Comments aren't just for us, but also for the developers using the API.

## Unsupported Uses
You are able to make your own API calls, however this is not supported. Any opened issues regarding unsupported uses will be closed.
Feel free to request new features instead of making your own api calls. It is not recommended.
[Unsupported Call Example](Will link to the wiki once created)
