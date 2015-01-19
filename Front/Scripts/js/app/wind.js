// Generated by CoffeeScript 1.8.0
(function() {
  define(["jquery", "./model"], function($, Xin) {
    var WIND;
    WIND = (function() {
      function WIND() {
        return;
      }

      WIND.prototype.loading_data_inset = function(url) {
        return $.ajax({
          url: url,
          type: "GET",
          datatype: "json",
          success: function(data) {
            var key, value;
            console.log("加载数据成功！");
            for (key in data) {
              value = data[key];
              $("#" + key).html(value);
            }
            return true;
          },
          error: function(meg) {
            console.log("加载数据失败，请检网络连接是否出现故障");
            return false;
          }
        });
      };

      WIND.prototype.loading_data_repeat_inset = function(wrapperID, url, markID) {
        return $.ajax({
          url: url,
          type: "GET",
          datatype: "json",
          success: function(data) {
            var $repeat_str, $str, data_arr, k, len, r_data, v, value, wrapper, wrapper_child_repeat_str, _i, _len;
            r_data = JSON.parse(data);
            data_arr = Xin.model.getData(markID, r_data);
            len = data_arr.length;
            wrapper = $("#" + wrapperID);
            wrapper_child_repeat_str = wrapper.html();
            $repeat_str = $(wrapper_child_repeat_str);
            wrapper.children().remove();
            for (_i = 0, _len = data_arr.length; _i < _len; _i++) {
              value = data_arr[_i];
              $str = $repeat_str.clone();
              for (k in value) {
                v = value[k];
                $str.find('.' + k).html(v);
                $str.attr('data-id', value['ID']);
              }
              $str.appendTo(wrapper);
            }
          },
          error: function(meg) {
            console.log("加载数失败:" + meg);
          }
        });
      };

      return WIND;

    })();
    return WIND;
  });

}).call(this);