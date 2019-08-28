var inputString = prompt('Enter the expression you want to count, patern:', '3.5 +4*10-5.3 /5 =')

function Calculater(){
    var result = 0,
        arr = [],   
        patern = /(((\d+\.\d+)|\d+)|[\+\-\*\/\=])/g;

    arr = inputString.match(patern);

    if(+arr[0]!=="NaN")
    {
    result+=+arr[0];
    }

    for (var i=0; i< arr.length; i++){

        switch(arr[i])
        {
            case "+": result+=+arr[i+1];
                break;
            case "*": result*=+arr[i+1];
                break;
            case "-": result-=+arr[i+1];
                break;
            case "/": result/=+arr[i+1];
                break;
            case "=":
                continue;
        }
    }
    var str_result = result.toFixed(2);

    return str_result;
}
alert(Calculater());