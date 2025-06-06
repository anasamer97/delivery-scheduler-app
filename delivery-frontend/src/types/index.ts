export interface DeliverySlotDto {
  startTime: string;
  endTime: string;
  isGreen: boolean;
}

export interface DeliveryOptionDto {
  date: string;
  timeSlots: DeliverySlotDto[];
}

export interface ProductDto {
  id: number;
  productType: "InStockProducts" | "FreshFoodProducts" | "ExternalProducts";
}
