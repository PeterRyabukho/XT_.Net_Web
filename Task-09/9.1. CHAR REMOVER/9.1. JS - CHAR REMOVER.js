var myString = prompt("Enter string to remove same chars: ", "");
alert(myString);

//var mySep = myString.split("?", "!", ":", ";", ",", ".", " ");
//alert(mySep);

var arr = myString.split('');
alert(arr);
var separator =["?", "!", ":", ";", ",", ".", " "];

var words =[],
    start =0;

arr.forEach(function(letter, i)
{
    if(separator.indexOf(letter) != -1)
    {
        words.push(myString.substr(start, i - start));
        start = i + 1;
        
    }
});
words.push(myString.substr(start));
alert(words);

var listOfSameLetters={};

words.forEach(function (word)
{
    word.split('').forEach(function(letter, i)
    {
        if(!listOfSameLetters[letter] && -1 !=word.indexOf(letter, i+1))
        {
            listOfSameLetters[letter] = 1;
        }
    });
});

for (var key in listOfSameLetters) 
{
    alert(key);
}

var removeString = arr.filter(function(findValue)
{
    return !listOfSameLetters[findValue];
}).join('');

alert(removeString);
//for(var i=0; i<myString.length;i++){
    //alert(mySep[i]);
//}