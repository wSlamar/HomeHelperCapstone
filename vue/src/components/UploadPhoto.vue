<template>
  <!-- eslint-disable --> <!-- This disables annoying eslink warning messages in the html       -->
    <!-- This is the dropzone component that will give a place to drop the image to be uploaded -->
    <!-- there are two custom events the component listens for:                                 -->
    <!--       the vdropzone-sending event which is fired when dropzone is sending an image     -->
    <!--       the vdropzone-success event which is fired when dropzone upload is successful    -->
    <vue-dropzone
        id="dropzone"
        class="mt-3"
        v-bind:options="dropzoneOptions"
        v-on:vdropzone-sending="addFormData"
        v-on:vdropzone-success="getSuccess"
        :useCustomDropzoneOptions="true"
    ></vue-dropzone>
</template>


<script>
/* eslint-disable */
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";

export default {
    name: "uploadphoto",
    components: {
        vueDropzone: vue2Dropzone
    },
    data(){
        return {
            //-------------------------------------------------------------------------------------
            // TODO: substitute your actual Cloudinary cloud-name where indicated in the URL
            //-------------------------------------------------------------------------------------
            dropzoneOptions: {
                imgUrl:"",
                url: "https://api.cloudinary.com/v1_1/deanzhangtech/image/upload",  
                thumbnailWidth: 250,
                thumbnailHeight: 250,
                maxFilesize: 2.0,
                acceptedFiles: ".jpg, .jpeg, .png, .gif",
                uploadMultiple: false,
                addRemoveLinks: true,
                dictDefaultMessage: 'Drop files here to upload. </br> Alternatively, click to select a file for upload.',                
            },      
        }
    },

    methods:{
        /******************************************************************************************
         * The addFormData method is called when vdropzone-sending event is fired
         * it adds additional headers to the request
         ******************************************************************************************/
        //--------------------------------------------------------------------------------------------
        // TODO: substitute your actual Cloudinary api-key where indicated in the following code
        // TODO: substitute your actual Cloudinary upload preset where indicated in the following code
        //----------------------------------------------------------------------------==---------------   
        addFormData(file, xhr, formData) {
            formData.append("api_key", "261873488686254");                // substitute your api key
            formData.append("upload_preset", "qesu1qfw ");   // substitute your upload preset
            formData.append("timestamp", (Date.now() / 1000) | 0);
            formData.append("tags", "vue-app");
        },
         /******************************************************************************************
         * The getSuccess method is called when vdropzone-success event is fired
         ******************************************************************************************/
        getSuccess(file, response) {
            const imgUrl = response.secure_url;   // store the url for the uploaded image
            this.imgUrl = imgUrl;
            this.$emit("image-upload", imgUrl);   // fire custom event with image url in case someone cares
        },
    }
}
</script>

<style scoped>
vue-dropzone{
    width: 1000px;
}
</style>
