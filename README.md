## Logger Library with Client
Design and implement a logger library that applications can use to log messages <br>
### Client/Application
<p>Client/application make use of your logger library to log messages to a sink<br>
<b>Message</b> -</p>
<ul>
<li>has content which is of type string has a level associated with it</li>
<li>is directed to a destination (sink)</li>
<li>has namespace associated with it to identify the part of application that sent the message</li>
</ul>
<b> Sink </b>-
<ul>
<li>This is the destination for a message (eg text file, database, console, etc)</li>
<li>Sink is tied to one or more message level</li>
</ul>


### Logger Library
<ul>
<li>Requires configuration during sink setup</li>
<li>Accepts messages from client(s)</li>
<li>Routes messages to appropriate sink based on the level </li>
<li>Supports following message level in the order of priority: FATAL, ERROR, WARN, INFO, DEBUG</li>
</ul>

<p><br><b>Sending messages</b>-<br>
• Sink need not be mentioned while sending a message to the logger library.<br>
• You specify message content and level <br><br>
<b>Logger configuration</b>- <br>
• Specifies all the details required to use the logger library.<br>
• Library can accept one or more configuration for an application</p>

