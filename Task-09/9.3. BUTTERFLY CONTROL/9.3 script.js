

// function onClick_fromAvToSel(){
//     var button = document.getElementById("fromAvToSel");
//     button.addEventListener("click", function(){


//         moveSelectedElement("AvailableColumn", "SelectedColumn");

//     });
// }

// function onClick_fromSelToAv(){
//     var button = document.getElementById("fromSelToAv");
//     button.addEventListener("click", function(){

//         // let selected = Array.from(AvailableColumn.options)
//         //     .filter(option => option.selected)
//         //     .map(option => option.value);

//         moveSelectedElement("SelectedColumn", "AvailableColumn");

//     });
// }

// function onClic_SelectMultipleOptions(){

// }

function moveSelectedElement(sourceID, destinationID) {
	var source = document.getElementById(sourceID);
	var dest = document.getElementById(destinationID);

	for(var item = 0; item < source.options.length; item++) {
		if(source.options[item].selected == true) {
				var option = source.options[item];

				var newOption = document.createElement("option");
				newOption.value = option.value;
				newOption.text = option.text;
                newOption.selected = false;
                
				dest.add(newOption);
				source.remove(item);

				item--;
		}
    }
    
}

function selectedAllOptions(selectID, isSelect) {
    var myColumn = document.getElementById(selectID);

    for (var item = 0; item < myColumn.options.length; item++) {
        myColumn.options[item].selected = isSelect;
    }
}

function moveMyElementToSelected(){
    if(AvailableColumn.options.length == 0){
        alert("List is empty!");
    }
    moveSelectedElement("AvailableColumn", "SelectedColumn");
}
function moveMyElementToAvailable(){
    if(SelectedColumn.options.length == 0){
        alert("List is empty!");
    }
    moveSelectedElement("SelectedColumn", "AvailableColumn");
}

function moveAllElementsToSelected(){
    if(AvailableColumn.options.length == 0){
        alert("List is empty!");
    }
    selectedAllOptions("AvailableColumn", true);
    moveSelectedElement("AvailableColumn", "SelectedColumn");
}
function moveAllElementsToAvailable(){
    if(SelectedColumn.options.length == 0){
        alert("List is empty!");
    }
    selectedAllOptions("SelectedColumn", true);
    moveSelectedElement("SelectedColumn", "AvailableColumn");
}

fromAvToSelButton.addEventListener("click", moveMyElementToSelected);
fromSelToAvButton.addEventListener("click", moveMyElementToAvailable);

fromAvToSelAllButton.addEventListener("click", moveAllElementsToSelected);
fromSelToAvALLButton.addEventListener("click", moveAllElementsToAvailable);

window.onload = selectedAllOptions("AvailableColumn", false);
window.onload = selectedAllOptions("SelectedColumn", false);
