//setTimeout(()=>(window.location = "page-2.2 second.html"), 3000);

var patern = /(page-\d\.\d\.html)/g;
var thisLocation = document.location.href;

var myLink = thisLocation.match(patern);

var myPageAdress = {
    pageOne: "page-1.1.html",
    pageTwo: "page-2.2.html",
    pageThree: "page-3.3.html",
    pageFour: "page-4.4.html",
    pageFive: "page-5.5.html",
};

var value ="0";
var id;

function listToNextPage(adress, seconds){
    //var seconds = 4;
    function countDown(){
        document.getElementById("mySeconds").innerText = seconds;
        seconds--;

        if (seconds < 0){
            window.location = adress;
        }
    }

    countDown();
    id = setInterval(countDown, 1000);
}

choosePage();

function startMyTimer(){
    listToNextPage(myLink[0], 4);
}

function pauseMyTimer(){
    value = mySeconds.textContent;
    clearInterval(id);
}

function resumeMyTimer(){
    var newTime = value;
    listToNextPage(myLink[0], +newTime);
}

// function pressButton(){
//     if (active == true){
//         active = false;
//     } else if (active == false){
//         active == true;
//     }
// }

function choosePage(){
     switch (myLink[0]){

        case 'page-1.1.html':
            listToNextPage(myPageAdress.pageTwo, 4);
            //document.addEventListener('DOMContentLoaded', timerForSwitchPages());
            break;
        case 'page-2.2.html':
            listToNextPage(myPageAdress.pageThree, 4);
            //setTimeout(()=>(window.location = "page-3.3.html"), 3000);
            break;
        case 'page-3.3.html':
            listToNextPage(myPageAdress.pageFour, 4);
            break;
        case 'page-4.4.html':
            listToNextPage(myPageAdress.pageFive, 4);
            break;
        case 'page-5.5.html':
                setTimeout(()=>(startAgainProgramOrClose()), 3000);
            break;
     }
 }


function startAgainProgramOrClose(){
    var valid = confirm("Do you want to repeat scrolling pages again (ok), or to exit this mode (cancel)?");
    if (valid == true){
        //setTimeout(()=>(window.location = "page-1.5.html"), 3000);
        //goto 'page-1.1';
        window.location = "page-1.1.html";
    } else if (valid == false){
        //window.open('', '_self', '');
        window.open('','_self').close();
        //close();
    }
}
var pause = document.getElementById("pause");
pause.addEventListener("click", pauseMyTimer, false);

var start = document.getElementById("start");
start.addEventListener("click", startMyTimer, false);

var resume = document.getElementById("resume");
resume.addEventListener("click", resumeMyTimer, false);
//var pauseButton = document.getElementById("pauseButton");
//pauseButton.addEventListener("click", pressButton());

//window.onload = choosePage;