<template>
    <div class="wrapper">
        <div class="submit-form">
            <div v-if="!submitted">
                <div class="form-group">
                <label for="title">Nick Name</label>
                <input
                    type="text"
                    class="form-control"
                    id="title"
                    required
                    v-model="model.nickName"
                    name="title"
                />
                </div>
        
                <div class="form-group">
                <label for="description">Comment</label>
                <input
                    class="form-control"
                    id="description"
                    required
                    v-model="model.comment"
                    name="description"
                />
                </div>
        
                <button @click="saveComment" class="btn btn-success">Submit</button>
            </div>
        
            <div v-else>
                <h4>You submitted successfully!</h4>
                <button class="btn btn-success" @click="newComment">Add</button>
            </div>
         </div>
    </div>
    
  </template>
  
  <script lang="ts">
  import { defineComponent } from "vue";
  import CommentService from "@/components/CommentService";
  import Comment from "@/components/Comment";
  import ResponseData from "@/components/Comment";
 
  
  export default defineComponent({
    name: "add-comment",
    data() {
      return {
        model: {
        id: null,
        nickName: "",
        comment: "",
        date: null,
        } as unknown as Comment ,
        submitted: false,
      };
    },
    methods: {
      saveComment() {
        let data = {
          nickName: this.model.nickName,
          comment: this.model.comment,
        };
  

        CommentService.create(data)
          .then((response: ResponseData) => {
            this.submitted = response.data;
          })
          .catch((e: Error) => {
            console.log(e);
          });
      },
      
  
      newComment() {
        this.submitted = false;
        this.model = {} as Comment;
      },
    },
  });
  </script>
  
  <style>
  .wrapper {
  display: flex;
  justify-content: center;
  align-items: center;
}

.submit-form {
  width: 50%; 
  padding: 20px;
  border: 1px solid #ccc; 
  border-radius: 5px; 
}

.form-group {
  margin-bottom: 20px;
}

.btn-success {
  width: 20%; 
}
  </style>