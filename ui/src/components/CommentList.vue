<template>
    <div class="comment">
        <div class="input-group">
            <input
                type="text"
                class="search-input"
                placeholder="Search by Nick Name"
                v-model="nickName"
            />
            <div class="input-group-append">
                <button
                class="btn btn-outline-secondary"
                type="button"
                @click="searchTitle"
                >
                Search
                </button>
            </div>
    </div>
</div>     
<div class="wrapper">
    <div class="list row">
        <ul class="list-group">
          <li
            class="list-group-item"
            :class="{ active: index == currentIndex }"
            v-for="(comment, index) in comments"
            :key="index"
            @click="setActiveComment(comment, index)"
          >
          <!-- <p class="comment_title">{{ comment.nickName }}</p> -->
          <p class="comment_body">{{ comment.comment }}</p>
          </li>
        </ul> 
    </div>
    <div class="selected-comment">
        <div v-if="selectedComment.id">
          <div>
            <label><strong>Nick Name:</strong></label> {{ selectedComment.nickName }}
          </div>
          <div>
            <label><strong>Comment:</strong></label>
            {{ selectedComment.comment }}
          </div>
          <div>
            <label><strong>Date:</strong></label>
            {{ selectedComment.date  }}
          </div>
        </div>
        <div v-else>
          <br />
          <p>Please click on a Comment...</p>
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
    name: "comments-list",
    data() {
      return {
        comments: [] as Comment[],
        selectedComment: {} as Comment,
        currentIndex: -1,
        nickName: "",
      };
    },
    methods: {
       retrieveComments() {
        CommentService.getAll()
          .then((response: ResponseData) => {
            this.comments = response.data;
            this.comments.forEach(x => {
                x.date = new Date(x.date.getDate());
            });
            console.log(response.data);
          })
          .catch((e: Error) => {
            console.log(e);
          });
      },
  
      setActiveComment(comment: Comment, index = -1) {
        this.selectedComment = comment;
        this.currentIndex = index;
      },

      searchTitle() {
      CommentService.findByNickName(this.nickName)
        .then((response: ResponseData) => {
          this.comments = response.data;
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    },
    mounted() {
      this.retrieveComments();
    },
  });
  </script>
  
  <style>
  .wrapper {
  display: flex;
  justify-content: center;
  align-items: center;
}

.comment {
  flex: 1;
  padding-right: 15px;
}

.selected-comment {
  padding-left: 15px;
}

.list-group {
  display: flex;
  flex-direction: column;
  padding-left: 0;
  margin-bottom: 0;
}

.list-group-item {
  position: relative;
  display: block;
  padding: 0.75rem 1.25rem;
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.125);
}

.list-group-item.active {
  z-index: 2;
  color: #fff;
  background-color: #007bff;
  border-color: #007bff;
}

.comment_body {
  margin-bottom: 0;
  font-size: 1rem;
  font-weight: 400;
}
  </style>