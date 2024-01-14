
using PreventR;

var strValue = "This is a string";

string mayBeString = strValue.Prevent().NullOrWhiteSpace();

mayBeString = strValue.Prevent("InputValue").NullOrWhiteSpace();

mayBeString = strValue.Prevent("InputValue",() => new MyCustomException("InputValue", "Input Value Cannot be Empty")).NullOrWhiteSpace();


mayBeString = strValue.Prevent().Predicate(_ => string.IsNullOrEmpty(strValue));


mayBeString = strValue.Prevent().Foo();


var dict = new Dictionary<string, string>
{
    { "MyKey",strValue}
};


dict.Prevent().Empty();

dict.Prevent().MissingKey("MyKey");

var num = 0;

num.Prevent().Zero();
    