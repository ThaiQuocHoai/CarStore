var renderCar = function (arrCar) {
  if (arrCar.length > 0) {
    document.querySelector(".errorSearch").style.display = "none";
    document.querySelector(".table").style.visibility = "visible";
    var content = "";
    for (let i = 0; i < arrCar.length; i++) {
      var item = arrCar[i];
      let count = i + 1;
      content += `   
      <tr>
      <td>${count}</td>
      <td>${item.name}</td>
      <td>${item.color}</td>
      <td>${item.price}</td>
      <td>${item.quantity}</td>
      <td><img src="${item.image}" width="100" /></td>
      <td>${item.decription}</td>
      <td>${item.status}</td>
      <td><button class="btn btn-primary" onclick="updateFunction(${item.carId})">Update</button></td>
      <td><button class="btn btn-danger" onclick="deleteFunction(${item.carId})">Delete</button></td>
    </tr>
      `;
    }
    document.querySelector("#renderTbl").innerHTML = content;
  } else {
    document.querySelector(".errorSearch").innerHTML = "NO RESULT IS MATCHED!";
    document.querySelector(".table").style.visibility = "hidden";
  }
};

function myFunction() {
  var cate = document.querySelector("#cbCate").value;
  var valueSearch = document.querySelector("#txtSearch").value;

  console.log(cate);
  console.log(valueSearch);
    var link = "";
    if(valueSearch.length > 0){
         link = `https://localhost:5001/api/Car/get-car-search-filer-admin-page?Cate=${cate}&Index=1&PageSize=100&SearchValue=${valueSearch}`;
    } else {
        link = `https://localhost:5001/api/Car/get-car-search-filer-admin-page?Cate=${cate}&Index=1&PageSize=10`
    }

  axios({
    url: link,
    method: "GET",
    responseType: "json",
  })
    .then(function (result) {
      console.log(result.data);
      renderCar(result.data);
    })
    .catch(function (error) {
      console.log(error);
    });
}

var displayManager = function () {
  axios({
    url:
      "https://localhost:5001/api/Car/get-car-search-filer?Cate=1&Index=1&PageSize=100",
    method: "GET",
    responseType: "json",
  })
    .then(function (result) {
      console.log(result.data);
      renderCar(result.data);
    })
    .catch(function (error) {
      console.log(error);
    });
};

displayManager();

function deleteFunction(id) {
    // console.log(id);
  axios({
    url:
      `https://localhost:5001/api/Car/Delete-car?CarID=${id}`,
    method: "PUT",
    responseType: "json",
  })
    .then(function (result) {
      console.log(result.data);
      displayManager();
    })
    .catch(function (error) {
      console.log(error);
    });
}

function updateFunction(id){
    window.location.href = `http://127.0.0.1:5501/admin/update/update.html?${id}`;
}