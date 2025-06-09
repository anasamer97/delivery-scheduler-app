import  axios from "axios";
import type  { ProductDto, DeliveryOptionDto } from "../types";

const BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const getDeliveryOptions = async (products: ProductDto[]) => {
  const response = await axios.post<DeliveryOptionDto[]>(
  `${BASE_URL}/get-delivery-options`,
  products
);
  return response.data;
};

