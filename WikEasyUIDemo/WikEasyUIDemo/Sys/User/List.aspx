<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WikEasyUIDemo.Sys.User.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--列表 start--%>
     <form id="form_list" name="form_list" method="post">
    <table id="tab_list">
    </table>
    <div id="tab_toolbar" style="padding: 0 2px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                
                <td style="padding-left: 2px">
                
                   
                        <a href="#" onclick="$('#form_edit input').val('');OpenWin();return false;" id="a_add"
                            class="easyui-linkbutton" iconcls="icon-add">添加</a>
                    
                        <a href="#" onclick="DelData(0);return false;" id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>
                    
                </td>
                <td style="text-align: right; padding-right: 15px">
                    <input id="ipt_search" menu="#search_menu" />
                    <div id="search_menu" style="width:120px">
                        <div name="username">
                            账 号</div>
                        <div name="realname">
                            姓 名</div>
                        <div name="role">
                            角 色</div>
                    </div>
                </td>
            </tr>
        </table>
       
    </div>
     </form>
    <%--列表 end--%>
    <%--添加 修改 start--%>
    <div id="edit" class="easyui-dialog" title="编辑用户" style="width: 350px; height: 300px;"
        modal="true" closed="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="List.aspx">
        <table class="table_edit">
            <tr>
                <td class="tdal">
                    用户名：
                </td>
                <td class="tdar">
                    <input id="ipt_username"  name="ipt_username" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    密码：
                </td>
                <td class="tdar">
                    <input id="ipt_userpwd" name="ipt_userpwd" type="password" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    真实姓名：
                </td>
                <td class="tdar">
                    <input id="ipt_realname" name="ipt_realname" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    角色：
                </td>
                <td class="tdar">
            

                        <select id="ipt_role" class="easyui-combobox" name="ipt_role" editable="false">
                        <option value="0">管理员</option>
                        <option value="1">普通用户</option>
                        </select>
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    邮箱：
                </td>
                <td class="tdar">
 <input id="ipt_email" name="ipt_email" type="text" class="easyui-validatebox" validType="email"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    超级管理员：
                </td>
                <td class="tdar">
                    <input type="checkbox" name="ipt_isadmin" id="ipt_isadmin"  />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton"
            onclick="$('#edit').dialog('close');return false;">取消</a>
    </div>
    <%--添加 修改 end--%>
    <script type="text/javascript">
        
        $(function () {
            InitGird();
            InitSearch();
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '用户列表', //表格标题
                url: location.href, //请求数据的页面
                sortName: 'JSON_id', //排序字段
                idField: 'JSON_id', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '80%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                {field: 'cbx', checkbox: true },
	                { title: '账号', field: 'JSON_username', width: 150, sortable: true },
                    { title: '真实姓名', field: 'JSON_realname', width: 150 }
				]],
                columns: [[
                    { title: '所属角色', field: 'JSON_role',formatter:function(value,rec,index){return value==0?'管理员':'普通用户'},width: 120 },
                    { title: '是否超级管理员', field: 'JSON_isadmin',formatter:function(value,rec,index){return value==0?'否':'是'}, width: 100 },
                    { title: '邮箱地址', field: 'JSON_email', width: 150 }, 
                    { title: '操作', field: 'JSON_id', width: 80, formatter: function (value, rec) {
                        return '<a style="color:red" href="javascript:;" onclick="EditData(' + value + ');$(this).parent().click();return false;">修改</a>';
                    }
                    }
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });

        }
        //初始化搜索框
        function InitSearch() {
            $("#ipt_search").searchbox({
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的账号'
            });
        }

        //打开添加窗口
        function OpenWin() {
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        function GetInputData(id, cmd) {
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });
            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        //提交按钮事件
    function Add(uid) {
        if (!$("#form_edit").form("validate")) {
            return;
        }


        var json = GetInputData('edit', 'submit');
      
        json.id = uid;       
        $.post(location.href,json, function (data) {
            $.messager.alert('提示', data, 'info', function () {
                if (data.indexOf("成功") > 0) {
                    console.info(data);
                    $("#tab_list").datagrid("reload");
                    $("#edit").dialog("close");
                }

            });
        });

    }

    //修改链接 事件
    function EditData(uid) {
        $("#edit").dialog("open");
        $("#btn_add").attr("onclick", "Add(" + uid + "); return false;")       
 
        $.post(location.href, { "action": "queryone", "id": uid }, function (data) {
            var dataObj = eval("(" + data + ")"); //转换为json对象    
            console.info(dataObj);
            $("#form_edit").form('load', dataObj);
        });
    }

    //删除按钮事件
    function DelData(id) {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var selected = "";
                if (id <= 0) {
                    $($('#tab_list').datagrid('getSelections')).each(function () {
                        selected += this.JSON_id + ",";
                    });
                    selected = selected.substr(0, selected.length - 1);
                    if (selected == "") {
                        $.messager.alert('提示', '请选择要删除的数据！', 'info');
                        return;
                    }
                }
                else {
                    selected = id;
                }
                $.post(location.href, { "action": "del", "cbx_select": selected }, function (data) {
                    $.messager.alert('提示', data, 'info', function () { $("#tab_list").datagrid("reload"); });
                });

            }
        });
    }
    </script>
</asp:Content>
