function onClick_fromAvToSel(){
    var button = document.getElementById("fromAvToSel");
    alert(button);
    button.addEventListener("click", function(){

        let selected = Array.from(AvailableColumn.options)
            .filter(option => option.selected)
            .map(option => option.value);

        moveSelectedElement("AvailableColumn", "SelectedColumn");

    });
}

function onClick_fromSelToAv(){
    var button = document.getElementById("fromSelToAv");
    alert(button);
    button.addEventListener("click", function(){

        let selected = Array.from(AvailableColumn.options)
            .filter(option => option.selected)
            .map(option => option.value);

        moveSelectedElement("SelectedColumn", "AvailableColumn");

    });
}

function onClic_SelectMultipleOptions(){

}

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


//window.onload = onClick_fromSelToAv, onClick_fromAvToSel;
