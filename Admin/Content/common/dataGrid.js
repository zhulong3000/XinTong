/// <reference path="../JqueryEasyUI/jquery-1.8.0.min.js" />
/// <reference path="../JqueryEasyUI/jquery.easyui.min.js" />
var DataGrid = {
    //datagrid 属性默认设置
    datagridId: "",
    title: "", //一个URL，从远程站点获取数据
    loadMsg: '数据正在努力加载中,请稍后...',
    class: "easyui-datagrid", //防止加载二次url
    fit: true, //当True时设置该面板尺寸适合于它的父容器
    fitColumns: true, //True 就会自动扩大或缩小列的尺寸以适应表格的宽度并且防止水平滚动。
    nowrap: true, //当true时，显示数据在同一行上。默认true。
    rownumbers: true, //当true时显示行号。
    pagination: true, //当true时在DataGrid底部显示一个分页工具栏。默认false。
    pageNumber: 1, //当设置分页属性时，初始化的页码编号。默认从1开始
    pageSize: 12, //当设置分页属性是，初始化的页面大小。默认10行
    pageList: [12, 30, 45], //设置分页属性时，初始化页面的大小选择清单。默认[10,20,30,40,50]
    width: "auto",
    height: "auto",
    selectRow: 1,
    singleSelect: true, //当true时只允许当前选择一行。默认false。
    collapsible: true, //显示可折叠面板的按钮
    idField: 'id', //说明哪个字段是一个标识字段。
    striped: true, //True 就把行条纹化。（即奇偶行使用不同背景色）
    dBodyHeight: 0, //需要减去的高度

    remoteSort: false, //定义是否从服务器给数据排序。
    sortName: 'ID',    //根据某个字段给easyUI排序
    sortOrder: 'asc',  //定义列的排列顺序，只能是'asc'或'desc'。默认asc。
    columns:
                    [[
    //                                { field: 'ck', checkbox: true },
    //	                              { title: '主键', field: 'ID', sortable: true },
                    ]],
    //添加或编辑面板属性管理
    formDialogId: "",
    formId: "",
    formAddDialogName: "",
    formEditDialogName: "",
    formSubmitBtn: "",
    formResettBtn: "",
    //url地址管理,需要初始化
    queryParams: {}, //http提交的post参数
    actionUrl: "", //增删改查操作的url地址
    queryUrl: "/BorrowingProduct/GetList",  //datagrid加载数据url地址
    createUrl: "/BorrowingProduct/Create", //添加数据url地址
    editUrl: "/BorrowingProduct/Edit?ID=", //编辑数据url地址
    deleteUrl: "/BorrowingProduct/Delete?ID=", //编辑数据url地址

    init: function () {
        this.initDatagrid();
        $(this.formSubmitBtn).bind("click", function () {
            DataGrid.submitForm();
        });
        $(this.formResettBtn).bind("click", function () {
            DataGrid.clearForm();
        });
    },
    initBodyHeight: function () {
        var bh = parent.document.body.clientHeight;
        $("body").css("height", (bh - this.dBodyHeight) + "px");
        this.height = document.body.clientHeight;
    },
    initDatagrid: function () { //实现对DataGird控件的初始化绑定操作
        $(this.datagridId).datagrid({
            url: this.queryUrl, //指向后台的Action来获取当前菜单的信息的Json格式的数据
            queryParams: this.queryParams,
            loadMsg: this.loadMsg,
            title: this.title,
            width: this.width,
            height: this.height,
            class: this.class,
            //fit: this.fit,
            fitColumns: this.fitColumns,
            nowrap: this.nowrap,
            rownumbers: this.rownumbers,
            selectRow: this.selectRow,
            singleSelect: this.singleSelect,
            collapsible: this.collapsible,
            pagination: this.pagination,
            pageSize: this.pageSize,
            pageList: this.pageList,
            idField: this.idField,
            remoteSort: this.remoteSort,
            sortName: this.sortName,    //根据某个字段给easyUI排序
            sortOrder: this.sortOrder,
            columns: this.columns,
            loadFilter: this.pagerFilter_custom,
            toolbar: [
                        {
                            id: 'btnAdd',
                            text: "添加操作",
                            class: 'easyui-linkbutton',
                            iconCls: 'icon-add',
                            plain: "true",
                            handler: function () {
                                DataGrid.AddOrEditAction(0);
                            }
                        }, '-',
                        {
                            id: 'btnEdit',
                            text: '修改操作',
                            class: 'easyui-linkbutton',
                            iconCls: 'icon-edit',
                            plain: "true",
                            handler: function () {
                                DataGrid.AddOrEditAction(1);
                            }
                        }, '-',
                        {
                            id: 'btnDelete',
                            text: '删除操作',
                            class: 'easyui-linkbutton',
                            iconCls: 'icon-remove',
                            plain: "true",
                            handler: function () {
                                DataGrid.DeleteAction(); //实现直接删除数据的方法
                            }
                        }, '-',
                          {
                              id: 'btnReload',
                              text: '刷新操作',
                              class: 'easyui-linkbutton',
                              iconCls: 'icon-reload',
                              plain: "true",
                              handler: function () {
                                  DataGrid.datagridReload();
                              }
                          }
                    ]
        });
    },
    AddOrEditAction: function (state) { //弹出添加功能的对话框：新增（0），编辑（1）
        if (state == 0) {
            this.clearForm();
            $(this.formDialogId).dialog('open').dialog('setTitle', this.formAddDialogName);
            this.actionUrl = this.createUrl;
        } else if (state == 1) {
            var row = $(this.datagridId).datagrid("getSelected");
            if (row) {
                $(this.formDialogId).dialog('open').dialog('setTitle', this.formEditDialogName);
                $(this.formId).form("load", row);
                this.actionUrl = this.editUrl + row.ID;
            }
        }
    },
    DeleteAction: function () {
        var row = $(this.datagridId).datagrid("getSelected");
        if (row) {
            this.actionUrl = this.deleteUrl + row.ID;
            $.post(this.actionUrl, function (data) {
                data = eval("(" + data + ")");
                if (data.status) {
                    DataGrid.datagridReload();
                }
                alert(data.message);
            });
        } else {
            alert("请选中某行数据！");

        }
    },
    submitForm: function () { //绑定注册按钮的事件
        //判断用户的信息是否通过验证
        var validate = $(this.formId).form('validate');
        if (validate == false) {
            return false;
        }
        var postData = $(this.formId).serializeArray();
        //发送异步请求到后台保存用户数据
        $.post(this.actionUrl, postData, function (data) {
            data = eval("(" + data + ")");
            if (data.status) {
                //添加成功  1.关闭弹出层，2.刷新DataGird
                alert(data.message);
                $(DataGrid.formDialogId).dialog("close");
                DataGrid.datagridReload();
                DataGrid.clearForm();
            }
            else {
                alert(data.message);
            }
        });

    },
    clearForm: function () {
        $(this.formId).form("clear");
    },
    datagridReload: function () {   //重新加载datagrid的数据 
        $(this.datagridId).datagrid('reload');
    },
    pagerFilter_custom: function (data) { //客服端分页
        var dg = $(this);
        var opts = dg.datagrid('options');
        var pager = dg.datagrid('getPager');
        pager.pagination({
            onSelectPage: function (pageNum, pageSize) {
                opts.pageNumber = pageNum; //当前页码
                opts.pageSize = pageSize; //当前索引
                pager.pagination('refresh', {
                    pageNumber: pageNum,
                    pageSize: pageSize
                });
                dg.datagrid('loadData', data); //客服端分页
            }

        });
        if (!data.originalRows) {
            data.originalRows = (data.rows);
        }
        var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
        var end = start + parseInt(opts.pageSize);
        data.rows = (data.originalRows.slice(start, end));
        return data;
    }
};      