var displayCar = function (car) {
  var item = car;
  var col4 = "";
  var col8 = "";
  col4 = `
        <h2 class="text-center mb-3">${item.name}</h2>
        <img src="${item.image}" width="100%" height="100%"/>
    `;
  document.querySelector(".col-5").innerHTML = col4;
  col8 = `
  <form action="/admin/manager/manage.html">
    <h2 class="mb-3">Details of car</h2>
        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <td>
                        <input type="hidden" id="txtID" value="${item.carId}">
                        <input required type="text" id="txtName" value="${item.name}">
                    </td>
                </tr>
                <tr>
                    <th>Color</th>
                    <td>
                        <input required type="text" id="txtColor" value="${item.color}">
                    </td>
                </tr>
                <tr>
                    <th>Price</th>
                    <td>
                        <input required type="number" id="txtPrice" value="${item.price}">
                    </td>
                </tr>
                <tr>
                    <th>Quantity</th>
                    <td>
                        <input required type="number" id="txtQuantity" value="${item.quantity}">
                    </td>
                </tr>
                <tr>
                    <th>Image</th>
                    <td>
                        <input required type="text" id="txtImage" value="${item.image}">
                    </td>
                </tr>
                <tr>
                    <th>Decription</th>
                    <td>
                        <input required type="text" id="txtDescription" value="${item.decription}">
                    </td>
                </tr>
                <tr>
                    <th>CategoryID</th>
                    <td>
                        <select id="txtCate">
                            <option value="1">Sedan</option>
                            <option value="2">SUV</option>
                            <option value="3">Coupes</option>
                            <option value="4">Van</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th>Status</th>
                    <td>
                        <select id="txtStatus">
                            <option value="true">True</option>
                            <option value="false">False</option>
                        </select>
                    </td>
                </tr>
            </thead>
        </table>
        <button type="submit" class="btn btn-success" onclick="UpdateFunction()">Update</button>
        </form>
    `;
  document.querySelector(".col-7").innerHTML = col8;
};
//
var display = function () {
  var link = window.location.href;
  var id = link.split("?")[1];
  axios({
    url: `https://localhost:5001/api/Car/find-by-id?CarID=${id}`,
    method: "GET",
    responseType: "json",
  })
    .then(function (result) {
      console.log(result.data);
      displayCar(result.data);
    })
    .catch(function (error) {
      console.log(error);
    });
};

display();

function UpdateFunction() {
  var carId = document.querySelector("#txtID").value;
  var carname = document.querySelector("#txtName").value;
  var color = document.querySelector("#txtColor").value;
  var price = document.querySelector("#txtPrice").value;
  var quantity = document.querySelector("#txtQuantity").value;
  var image = document.querySelector("#txtImage").value;
  var decription = document.querySelector("#txtDescription").value;
  var categoryID = document.querySelector("#txtCate").value;
  var status = document.querySelector("#txtStatus").value;

//   var car = new Car(
//     carId,
//     carname,
//     color,
//     price,
//     quantity,
//     image,
//     decription,
//     categoryID,
//     status
//   );

  axios({
    url: `https://localhost:5001/api/Car/Update-car?CarId=${carId}&Name=${carname}&Color=${color}&Price=${price}&Quantity=${quantity}&Image=${image}&Decription=${decription}&CategoryID=${categoryID}&Status=${status}`,
    method: "PUT",
    // data: //car,
    // {
    //   "carId": carId,
    //   "name": carname,
    //   "color": color,
    //   "price": price,
    //   "quantity": quantity,
    //   "image": image,
    //   "decription": decription,
    //   "categoryID": categoryID,
    //   "status": status,
    // },
    responseType: "json",
  })
    .then(function (result) {
      console.log(result.data);
    })
    .catch(function (error) {
      console.log(error);
    });
}
