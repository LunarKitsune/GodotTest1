Hi and welcome to this tutrial. I am LunarKitsune(on github), but more commonly known as username as Cheesypockets most elsewhere.

I intend to make this tutorial not only for my learning, but for others who want to get into gamedev/coding.

As the name of the Repo suggests this project will use the Godot game engine. For coding I will be using C#
However you may use Godot(.gd files) to code as well and it will more closely resemble a mix of python and bash.

This particular markdown file will skim over the basics of coding, and then the rest will be explained in other
README files as the tutorial works more with different objects, properties, and interactive elements that we will
be giving players.

However, I will give you resources just in case if you are going to use either C# or Godot, as well as a link to
the Godot main page documents here:

 - [C# introductory programming by Microsoft](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/)
 - [GD Scripting (godot programming) documentation](https://docs.godotengine.org/en/stable/tutorials/scripting/gdscript/index.html)
 - [Introductiont to Godot Engine](https://docs.godotengine.org/en/stable/getting_started/introduction/index.html)

With that out of the way we can get started...

I will have an outline table of contents below. To get to a particular section you want
I will have the particular sections named and number as is. This way when you go to
<ins><b>highlight</b></ins> and use <ins><b> CRTL + F </b></ins> and press Next or Down (depending on browser)
Your selection will be highlighted or you will be booted to that section! ^_^

===== Table of Contents =====
<br> 01. Coding Basics
 - 01.1 Variables
 - 01.2 Objects and Types
 - 01.3 Functions
 - 01.4 Control Flows
 - 01.5 Classes (object frameworks)

<br> 02. Godot Basics
- 02.1 Basic Controls
- 02.2 Documentation Lookup
- 02.3 (TBD)

<br>
===== 01. Coding Basics =====

At the very least to start this tutorial and get to know how to read code
we need to know some coding basics. The coding basics I will go over are:
 - Variables
 - Objects and Types
 - Functions
 - Control Flows
 - Classes (object frameworks)

----- 01.1 Variables -----
So to start off we will discuss a simple object called variables. 
Variables can be best described as a labeled moving box that contains data. 
Depending on the language you use the data type can be specified, and then
variables are defined.

Lets use a simple example:
Int number = 5;
<!--Need better visuals here-->
<br>{++++++}
<br>{++Int++}..... => Stored in a crate that holds only integer objects: the number 5!
<br>{++++++}

Variable definition will generally go by this simple pattern: <ins><b>(accessability) (type) (name) = (data)</b></ins>
* Note here if accessability such as public or private are not defined then it will be compiled as private data

----- 01.2 Objects and Types -----

So now that we know the basic defining of a variable and its parts its time to move
on to the next topic: Objects and Types.

The variable in the previous segment can also be known as an integer (int) object. Yes this will be confusing at
first, but with a little explanation it will become more clear.  

Objects can be summed up to be a variable with properties and definitions. They usually have a class framework behind them
that will discuss in a later section and can be made of of many types...including your own that you will eventually make!

The most common types of objects are int (integers), strings (an array/list of characters) and floats and doubles (decimal based numbers).
There are more defining types that can be looked up using the C# documentation that microsoft gives you as well as documentation from other
languages and the main differences will generally be among number types with how many bytes their object takes up.

<!--Need better visuals here-->
As a brief example floats is 4 bytes => (byte 1) (byte 2) (byte 3) (byte 4) Where as doubes are 8 bytes meaning more data.
Generally in programming this means if we have to do comparisons or in general read these types 1 will take longer than the other.
ESPECIALLY in bigger programs. 
===== Godot Basics =====
