/*
对于json字符串或者js对象均转换为对象，免去频繁的判断，代替 JSON.parse()方法
依赖于jQuery
add at 2017-12-26

使用示例：
$.getObjFromData('{"name":"zhang","age":123}')
//{name: "zhang", age: 123}
$.getObjFromData({name:"zhang",age:123})
//{name: "zhang", age: 123}
*/
$.extend({
    getObjFromData: function (data) {
        if (typeof data == "string") {
            return JSON.parse(data);
        } else {
            return data;
        }
    }
});
