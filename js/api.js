var renderCar = function (arrCar) {
  var content = "";
  for (let i = 0; i < arrCar.length; i++) {
    var item = arrCar[i];
    // console.log(item.carId);
    var car = new Car(
      item.carId,
      item.name,
      item.color,
      item.price,
      item.quantity,
      item.image,
      item.decription,
      item.categoryID,
      item.status
    );
    content += `
          <a href="#">
            <div class="car__item">
              <div class="car__text">
                <p>${item.name}</p>
                <p>From ₫${item.price}</p>
              </div>
              <div class="car__img">
                <img
                  src="${item.image}"
                  alt=""
                />
              </div>
            </div>
          </a>
    `;
  }
  document.querySelector("#content").innerHTML = content;
};

document.querySelector("#btnSendan").onclick = function () {
  axios({
    url: `https://localhost:5001/api/Car/get-car-search-filer?Cate=1&Index=1&PageSize=6`,
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

document.querySelector("#btnSUV").onclick = function () {
  axios({
    url: `https://localhost:5001/api/Car/get-car-search-filer?Cate=2&Index=1&PageSize=6`,
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

document.querySelector("#btnCoupes").onclick = function () {
  axios({
    url: `https://localhost:5001/api/Car/get-car-search-filer?Cate=3&Index=1&PageSize=6`,
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

document.querySelector("#btnVan").onclick = function () {
  axios({
    url: `https://localhost:5001/api/Car/get-car-search-filer?Cate=4&Index=1&PageSize=6`,
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

var renderCarFirst = function (){
  axios({
    url: `https://localhost:5001/api/Car/get-car-search-filer?Cate=1&Index=1&PageSize=6`,
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

renderCarFirst();
