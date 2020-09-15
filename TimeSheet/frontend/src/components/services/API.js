import Axios from "axios";

export default Axios.create({
  baseURL: "https://localhost:44321/api",
  headers: {
    Authorization:
      "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhc2RmQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhc2RmZyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjAwMjI0NTI2LCJpc3MiOiJUaW1lU2hlZXQiLCJhdWQiOiJUaW1lU2hlZXQifQ.BYpdlNAW7W0Wae4FiY-PxnwD0vA_uOqxlOmSMOJtjZg",
  },
});
