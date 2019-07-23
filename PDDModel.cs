using System.Collections.Generic;

namespace MallInfoCrawler.Models
{
    class PDDModel
    {

        public class IResp
        {

        }

        // 接口错误响应体
        public class ErrorResp : IResp
        {
            /// <summary>
            /// 
            /// </summary>
            public string success { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int error_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string error_msg { get; set; }
        }

        // 手机图形验证码响应体
        public class VerifyAuthToken
        {
            /// <summary>
            /// 
            /// </summary>
            public int error_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string verify_auth_token { get; set; }
        }

        // 需要发送图形验证码响应体
        public class NeedCaptch
        {
            public string anti_content { get; set; }
            public string verify_auth_token { get; set; }
        }


        // 图形验证码检测响应体
        public class VerifyStatus
        {
            public int code { get; set; }
            public string result { get; set; }
        }

        // 账号登录接口响应体
        public class LoginOK
        {
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string access_token { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string acid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uin { get; set; }
        }

        // 店铺信息接口响应体
        public class PriceItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string txt { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int font { get; set; }
        }

        public class Mall_couponsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 满99减6
            /// </summary>
            public string batch_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int mall_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int discount_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int discount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int min_amount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int cat_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string link_url { get; set; }
            /// <summary>
            /// 满99元使用
            /// </summary>
            public string rules_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int display_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int user_limit { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int can_taken_count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_taken_out { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int remain_quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int start_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int end_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int source_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bg_pic_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bg_grey_pic_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<PriceItem> price { get; set; }
            /// <summary>
            /// 有效期: 2019.6.13-7.12
            /// </summary>
            public string time_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string batch_sn { get; set; }
        }

        public class Share_coupon_info
        {
            /// <summary>
            /// 
            /// </summary>
            public string in_activity { get; set; }
        }


        public class Super_mall_couponsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 满99减6
            /// </summary>
            public string batch_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int mall_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int discount_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int discount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int min_amount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int cat_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string link_url { get; set; }
            /// <summary>
            /// 满99元使用
            /// </summary>
            public string rules_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int display_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int user_limit { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int can_taken_count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_taken_out { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int remain_quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int start_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int end_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int source_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bg_pic_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bg_grey_pic_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<PriceItem> price { get; set; }
            /// <summary>
            /// 有效期: 2019.6.13-7.12
            /// </summary>
            public string time_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string batch_sn { get; set; }
        }

        public class MallInfo : IResp
        {
            internal readonly bool goods_name;

            /// <summary>
            /// 
            /// </summary>
            public int mall_id { get; set; }
            /// <summary>
            /// 溫建居家店
            /// </summary>
            public string mall_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string logo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int goods_num { get; set; }
            /// <summary>
            /// 欢迎广大的多多们光临本小店，非常荣幸能够为您服务。 小店目前专营厨房卫浴板块，主要有淋浴喷头、阀门、地漏、水暖、花洒淋浴等一系列家具建材！各款产品都讲究精益求精，希望能够给亲们带来足够的拼团及便利！
            /// </summary>
            public string mall_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string company_phone { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string offline_note { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int chat_enable { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string refund_address { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int score_avg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int staple_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int mall_sales { get; set; }
            /// <summary>
            /// 已拼10万+件
            /// </summary>
            public string sales_tip { get; set; }
            /// <summary>
            /// 商品数量: 119
            /// </summary>
            public string goods_num_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int region_emergent { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int is_open { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int wms_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Mall_couponsItem> mall_coupons { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string is_favorite { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int server_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Share_coupon_info share_coupon_info { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string if_brand_story { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> activitys { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Super_mall_couponsItem> super_mall_coupons { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int mall_activity_count_down_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> mall_label_list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string immersion_flag { get; set; }
        }
        // 商品信息接口响应体
        public class SpecsItem
        {
            /// <summary>
            /// 套餐
            /// </summary>
            public string spec_key { get; set; }
            /// <summary>
            /// 200支（1盒）
            /// </summary>
            public string spec_value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long spec_key_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long spec_value_id { get; set; }
        }

        public class SkuItem
        {
            /// <summary>
            /// 
            /// </summary>
            public long sku_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long goods_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string thumb_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long init_quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long limit_quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long sold_quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_onsale { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string spec { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<SpecsItem> specs { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long normal_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long group_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long old_group_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long market_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long weight { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_sku_sn { get; set; }
        }

        public class GalleryItem
        {
            /// <summary>
            /// 
            /// </summary>
            public long id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long goods_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long width { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long height { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long priority { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long type { get; set; }
        }

        public class @groupItem
        {
            /// <summary>
            /// 
            /// </summary>
            public long id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long group_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long goods_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long customer_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long start_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long end_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long buy_limit { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long order_limit { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_open { get; set; }
        }

        public class Service_promiseItem
        {
            /// <summary>
            /// 
            /// </summary>
            public long id { get; set; }
            /// <summary>
            /// 全场包邮
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 全场包邮
            /// </summary>
            public string dialog_type { get; set; }
            /// <summary>
            /// 所有商品均无条件包邮
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long top { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long top_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long navigation { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string navigation_url { get; set; }
        }

        public class GoodsInfo : IResp
        {
            /// <summary>
            /// 
            /// </summary>
            public string goods_sn { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long goods_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cat_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long mall_id { get; set; }
            /// <summary>
            /// 【2种棉头】喜多婴儿多用途棉棒新生儿童细棉花棒宝宝清洁棉棒
            /// </summary>
            public string goods_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_app { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long event_type { get; set; }
            /// <summary>
            /// 品名:喜多超细纸轴多用途柔棉棒400支/200支 
            /// 材质:棉球:棉 棒轴:纸制 
            /// 特点:棉球密实不松散、不脱落。超细纸轴,棉头不添加荧光剂,使用更安心。两种不同造型棉头,多种用途,方便清洁宝宝不同部位所需。内置提拉纸条,轻松拿取棉签,不易沾染手指细菌。
            /// 注意事项:
            ///请不要将棉棒过深的插入耳内。
            ///严禁儿童自行使用。
            ///规格:婴儿用 包装:200支入 保存期限:三年 合格     生产日期:标示于包装上
            /// </summary>
            public string goods_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long market_price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_onsale { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string thumb_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string hd_thumb_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string allowed_region { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string country { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string warehouse { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long goods_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string image_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_refundable { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long quick_refund { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_pre_sale { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long pre_sale_time { get; set; }

            public string share_desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long rv_image { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long rv { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long gpv { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string skip_goods { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long shipment_limit_second { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<SkuItem> sku { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<GalleryItem> gallery { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<@groupItem> @group { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long sales { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_mall_rec { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Service_promiseItem> service_promise { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long tag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cost_template_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long show_rec { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_folt { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_installment { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long app_new { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string cost_province_codes { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long server_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_home_delivery { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long second_hand { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> images { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long is_mall_dsr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long created_at { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long single_group_card { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long has_promotion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long has_activity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long app_client_only { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long we_chat_only { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long quantity { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long home_delivery_info { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long enable_invoice { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cat_id_1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cat_id_2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cat_id_3 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long cat_id_4 { get; set; }
        }

        public class ObtainCaptch
        {
            public int type { get; set; }
            public int code { get; set; }
            public List<string> pictures { get; set; }
            public List<string> text { get; set; }
        }

        public class VerifyCode
        {

            public string captchaType { get; set; }

            public string sceneId { get; set; }

            public string sign { get; set; }

            public int code { get; set; }

            public string message { get; set; }

            public string picture { get; set; }

            public int serverTime { get; set; }
        }
    }

}