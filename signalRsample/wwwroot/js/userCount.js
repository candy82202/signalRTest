
//建立連線
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HtttpTransport).build();

connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();

});
connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();

});
function newWindowLoadedOnColint() {
    //這裡要用invoke不然抓不到值，會顯示undefied
    connectionUserCount.invoke("NewWindowLoaded").then((value)=> console.log(value));
}


//開始連線
function fulfilled() {
    console.log("連線成功")
    newWindowLoadedOnColint();
}

function rejected() {
//rejected logs
}

connectionUserCount.start().then(fulfilled, rejected);