# RandomLibrary
#### Maui/Blazor app to scan the ISBN of books to a consolidated library, and randomly recommend one to read next. Made with MudBlazor components.

## Installation

***TODO***

## Usage
Start building a library by opening the scanner button in the bottom right corner. 

<img src="https://github.com/Jason-Patrick/RandomLibrary/assets/65310110/f40b59f1-8e0a-4f1a-84b7-dd5c83a221b4" width="300">

  

This will open the phone's camera, and will automatically register and scan ISBN barcodes found usually on the backs of books.
Functionality for barcode scanning credit goes to Johnathan Dick's [ZXing.Net.Maui](https://github.com/Redth/ZXing.Net.Maui).

Using REST call to GoogleApis *books* endpoint, the metadata for the book is retrieved and present in a popup up modal. Users can see the title, author, description, etc. and can choose to add the book to their library.

<img src="https://github.com/Jason-Patrick/RandomLibrary/assets/65310110/8fed8c48-fb49-4592-a02b-53f5ba68b265" width="300">
  

The library is stored completely locally, so available offline. Users can review a book's metadata, mark as read/unread, or delete entirely from the library. Read books are outlined in green and the current randomly assigned book is marked blue.

<img src="https://github.com/Jason-Patrick/RandomLibrary/assets/65310110/f3e11ba9-5da6-46b5-93e0-4368a9427adb" width="300">

  
Once the library is populated, one random unread book will be "assigned" to read next. No more choice paralysis!

<img src="https://github.com/Jason-Patrick/RandomLibrary/assets/65310110/9c0d95f9-1ee5-4db5-a589-285cbbc0b4fc" width="300">

## Road map and TODOs

* Edit book info in modal if incorrect information
* Edit book info of library books
* App icon and splash screen
* Custom styling from default MudBlazor styling and color scheme
* Manual book entry
* Filter library on read, unread, category, etc.
* Publish for download through open source android app sources (e.g. FDroid)
  * (Apple store, if demand)

## Credit / Acknowledgement

MudBlazor - https://mudblazor.com/
ZXing.Net.Maui - https://github.com/Redth/ZXing.Net.Maui
