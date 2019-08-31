var app = angular.module('app', []);
app.service("api", ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
  this.server_url = "http://localhost:57709/cmssvr.asmx/";
    this.exec = function (action, param, method) {
        var delay =  $q.defer();
       var rootScope = $rootScope;
        let ToUrl = action;
        let CData = null;
        let CType;

        method = method||"post";

        if (method == "get") {
            if (param) {
                CData = $.param(param);
                if (ToUrl.indexOf("?") < 0)
                    ToUrl = ToUrl + "?" + CData;
                else
                    ToUrl = ToUrl + "&" + CData;
                CData = {};
            } else {
                // console.log("param=null");
            }
        } else {
            method = "post";
            if (ToUrl.indexOf(".ashx") > 0) {
                CData = $.param(param);
                CType = "application/x-www-form-urlencoded"; //"multipart/form-data";
            } else {
                CType = 'application/json';
                if (param != null)
                    CData = JSON.stringify(param);
            }
        }
        // console.log("call api :" + ToUrl+":"+JSON.stringify(CData));

        rootScope.loading = true;
        var promise = $http({
            url: this.server_url + ToUrl,
            method: method,
            data: CData,
            //timeout: 10000,
            withCredentials: true,
            headers: {
                'Content-Type': CType,
                //"cache-control": "no-cache"
            }
        })
            .then(function (response) {
                // console.log("response:" + JSON.stringify(response));
                var result = response.data.d;
                var tyresult = typeof (result);
                if (tyresult === "string") {
                    var ret = [];
                    try {
                        ret = JSON.parse(result);
                    } catch (err) {
                        console.log(result);
                    
                    }
                    delay.resolve(ret);
                }
                else if (tyresult === "object") {
                    delay.resolve(result);
                }

                rootScope.loading = false;
            }, function (err) {
                //console.log(error.statusText + error.status);
           
                    rootScope.loading = false;
                    delay.reject(err.message);
                    //alert(error.statusText + ":" + error.data.ExceptionMessage);
                if (err.status != 0) {
                    alert("请求服务器错误:status=" + err.status + "," + err.statusText);
                } else {
                    alert("无法连接服务器,请检查网络设置");
                    }
            
            });


        //return promise;
        return delay.promise;
    }
}]);
app.controller("testctrl", ['$scope', 'api', function ($scope, api) {
    $scope.test = "haha";
    api.exec("Test").then(function (result) {
        console.log(result);
    });
}]);  
