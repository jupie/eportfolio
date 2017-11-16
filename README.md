

# .Net Bot Framework



What is a Bot ?

A bot is a Robot. In case of This framework it is a new method to interact with the user by using speech in written or spoken form.

Businesscases

(Enter Business Cases here)
  
  
  
  
  
The core concepts

Channel

A Channel is a connection between the Bot and communication apps. ( All Microsoft communication Apps)

Bot Connector

Interface for the Channels , which designs messages for each app. (The developer don&#39;t  need to design a message for each channel). It is possible to connect to multiple channels at the same Time with the bot.

Activity

The Bot Connector uses a Activity to communicate with the Chanel. The activity contains messages.

Message

A message  contains the information the user or the bot wants to transmit. This could be Text(String) or a Richcard.

Dialog

Dialogs are similar to MVC Controller. They can post information

Richcards

Richcards are media values like gifs, which the Bot can send to the User and to the other direction.

How to use .Net Bot Framework?

There are three ways to use the Botframework:

1. Azure
2. Visual Studio 2017

It is possible to write the Bot in Csharp or Node.js.

Requirements

1. Install Visual Studio 2017 for Windows.

2. In Visual Studio, update all extensions to their latest versions.

3. Download the Bot Application, Bot Controller, and Bot Dialog .zip files. Install the templates by copying the .zip files to your Visual Studio 2017 project templates directory.

Create Project

1. Right-click on the project and select Manage NuGet Packages.

2. In the Browse tab, type &quot;Microsoft.Bot.Builder&quot;.

3. Locate the Microsoft.Bot.Builder package in the list of search results, and click the Update button for that package.

4. Follow the prompts to accept the changes and update the package.

Debug the Bot with Bot Framework emulator

1. Run the Project.
2. It will start your browser. Copy the URL
3. Start the Emulator
4. Paste the URL to the url prompt add &quot;&lt;the url&gt;/api/messages&quot;

