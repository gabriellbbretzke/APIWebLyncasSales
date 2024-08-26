import { API_URL } from "./config.js";
/**
 * Service to call HTTP request
 */

export const ApiService = {
 
  get(resource) {
    return fetch(`${API_URL}/${resource}`)
    .then((data) => {
      console.log(data);
      console.log("DataJson", data.json());
      return data.json();
    })
    .catch((error)=> {
      console.log(error);
    });
  },

  getByID(resource, params){
    return fetch(`${API_URL}/${resource}/${params}`)
    .then((data) => {
      return data.json();
    })
    .catch((error)=> {
      console.log(error);
    });
  },

  post(resource, info) {
    return fetch(`${API_URL}/${resource}`,
    {
      method: 'POST',
      headers: {
        'Content-Type' : 'application/json'
      },
      body: `${info}`
    })
    .then((data) => {
      return data.json(); 
    })
    .catch((error)=> {
      console.log(error);
    });
  },

  put(resource, info) {
    return fetch(`${API_URL}/${resource}`, 
    {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: `${info}`
    })
    .then((data) => {
        return data.json(); 
    })
    .catch((error)=> {
        console.log(error);
    });
  },

  delete(resource, params) {
    return fetch(`${API_URL}/${resource}/${params}`,
    {
      method: 'DELETE',
    })
    .then((data) => {
      return data.json(); 
    })
    .catch((error)=> {
      console.log(error);
    });
  },
};