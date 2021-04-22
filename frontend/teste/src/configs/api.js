import axios from 'axios';

const api = axios.create({
     baseURL: 'https://localhost:44380/api/v1/',
});

export default api;