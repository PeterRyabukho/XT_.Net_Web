var myString = prompt("Enter string to remove same chars: ", "");

var arr = myString.split('');

var separator =["?", "!", ":", ";", ",", ".", " "];

var words = [],
    start = 0;

arr.forEach(function(letter, i)
{
    if (separator.indexOf(letter) != -1)
    {
        words.push(myString.substr(start, i - start));
        start = i + 1;
        
    }
});

words.push(myString.substr(start));

var listOfSameLetters={};

words.forEach(function (word)
{
    word.split('').forEach(function(letter, i)
    {
        if(!listOfSameLetters[letter] && word.indexOf(letter, i+1) != -1)
        {
            listOfSameLetters[letter] = 1;
        }
    });
});

var removeString = arr.filter((findValue) =>(
    !listOfSameLetters[findValue])).join('');

alert(removeString);
