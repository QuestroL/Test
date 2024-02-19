import http from "@/http-common";

class CommentService {
  getAll(): Promise<any> {
    return http.get("/Comment/GetAllComments");
  }

  create(data: any): Promise<any> {
    return http.post("/Comment/AddComment", data);
  }

  update(data: any): Promise<any> {
    return http.put(`/Comment/UpdateComment`, data);
  }

  findByNickName(nickName: string): Promise<any> {
    return http.get(`/Comment/GetByNickName?nickName=${nickName}`);
  }
}

export default new CommentService();