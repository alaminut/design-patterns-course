# Coding Exercise for Builder Pattern

You are asked to implement the Builder design pattern for rendering simple chunks of code.

Sample builder:

var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age","int");

Expected output:

public class Person
{
  public string Name;
  public int Age;
}