var listCart = [];
$(document).ready(function () {
    loadData();
})
// console.log(item.carId);
// var car = new Car(
//   item.carId,
//   item.name,
//   item.color,
//   item.price,
//   item.quantity,
//   item.image,
//   item.decription,
//   item.categoryID,
//   item.status
// );
function loadData() {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('=');
    var sParameterName = sURLVariables[1];
    $.ajax({
        url: "https://localhost:5001/api/Car/find-by-id?CarID=" + sParameterName,
        method: "Get",
        //data: "",
        contentType: "application/json",
        dataType: "json"
    }).done(function (repponse) {
        var ihtml = $(`<h1><span class="value">` + repponse.name + `</span></h1>
    <table border="1" style="width: 100%">
        <tbody>
            <tr>
                <td style="width:700px; height:400px;" rowspan="2"><img src="`+ repponse.image + `" style = "width:700px; height:400px; margin:0px;"/></td>
                <td><p class="attributeCar">Decription:</br><span class="value"> `+
            repponse.decription + `</span></p> <p class="attributeCar">Color:<span class="value">` +
            repponse.color + `</span></p><p class="attributeCar">Price:<span class="value"> ` +
            repponse.price + `</span></p><p class="attributeCar">Quantity:<span class="value"> ` +
            repponse.quantity + `</span></p><p class="attributeCar">Category:<span class="value"> ` +
            repponse.categoryID + `</span></p></td>
            </tr>
            <tr>
                <td height="100px"><button style="margin-left:240px;background-color:#00adef;color:white;height:50px;width:360px;padding:0 10px" id="btnaddcart" onclick="addfunction()" >Add To Cart</button>
                </td>
            </tr>
        </tbody>
    </table>`);
        $('.detailpage').append(ihtml);
        debugger;
    }
    )
}

function addfunction() {
    if (sessionStorage["CART"] != null) {
        listCart = JSON.parse(sessionStorage["CART"].toString());
    }
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('=');
    var sParameterName = sURLVariables[1];
    $.ajax({
        url: "https://localhost:5001/api/Car/find-by-id?CarID=" + sParameterName,
        method: "Get",
        //data: "",
        contentType: "application/json",
        dataType: "json"
    }).done(function (repponse) {
        repponse.quantity = 1;
        var exist = false;
        if (listCart.length > 0) {
            $.each(listCart, function (index, value) {
                if (value.carId == repponse.carId) {
                    value.quantity++;
                    debugger;
                    exist = true;
                    return false;
                } 
            });
        }
        if (!exist) {
            listCart.push(repponse);
            debugger;
        }
        sessionStorage["CART"] = JSON.stringify(listCart);
    }
    )
}
