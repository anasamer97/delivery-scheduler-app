import  axios from "axios";
import type  { ProductDto, DeliveryOptionDto } from "../types";

const BASE_URL = "https://localhost:7023/api/delivery";

export const getDeliveryOptions = async (products: ProductDto[]) => {
  const response = await axios.post<DeliveryOptionDto[]>(
  `${BASE_URL}/get-delivery-options`,
  products
);
  return response.data;
};

