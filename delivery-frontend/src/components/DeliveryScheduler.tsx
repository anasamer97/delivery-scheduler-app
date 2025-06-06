import React, { useState } from "react";
import { getDeliveryOptions } from "../services/DeliveryService";
import type { DeliveryOptionDto, ProductDto } from "../types";

const productTypes = ["InStockProducts", "FreshFoodProducts", "ExternalProducts"] as const;
type ProductType = typeof productTypes[number];

const DeliveryScheduler = () => {
  const [products, setProducts] = useState<ProductDto[]>([]);
  const [deliveryOptions, setDeliveryOptions] = useState<DeliveryOptionDto[]>([]);
  const [selectedDate, setSelectedDate] = useState<string | null>(null);

  const addProduct = (type: ProductType) => {
    const newProduct: ProductDto = {
      id: products.length + 1,
      productType: type
    };
    setProducts([...products, newProduct]);
  };

  const fetchOptions = async () => {
    const options = await getDeliveryOptions(products);
    setDeliveryOptions(options);
  };

  return (
    <div className="p-4 flex flex-col items-center">
      <h2 className="text-xl font-semibold mb-4">Select Product Types</h2>

      <div className="flex gap-2 mb-4">
        {productTypes.map((type) => (
          <button
            key={type}
            onClick={() => addProduct(type)}
            className="px-3 py-1 border rounded hover:bg-blue-100"
          >
            {type}
          </button>
        ))}
      </div>

      <div className="mb-4 w-full max-w-md">
        <h3 className="font-semibold mb-2">Selected Products:</h3>
        {products.length > 0 ? (
          <ul className="list-disc pl-5">
            {products.map((p) => (
              <li key={p.id}>
                ID: {p.id}, Type: {p.productType}
              </li>
            ))}
          </ul>
        ) : (
          <p className="text-sm text-gray-500">No products selected yet.</p>
        )}
      </div>

      <button
        onClick={fetchOptions}
        className="bg-blue-600 text-white px-4 py-2 rounded mb-4"
      >
        Load Delivery Options
      </button>

      <div className="flex gap-2 flex-wrap justify-center">
        {deliveryOptions.map((opt) => (
          <button
            key={opt.date}
            className={`px-3 py-1 border rounded ${selectedDate === opt.date ? "bg-blue-100" : ""}`}
            onClick={() => setSelectedDate(opt.date)}
          >
            {new Date(opt.date).toDateString()}
          </button>
        ))}
      </div>

      {selectedDate && (
        <div className="mt-6 w-full max-w-xl">
          <h3 className="text-center font-semibold mb-2">
            Time Slots for {new Date(selectedDate).toDateString()}
          </h3>
          <div className="grid grid-cols-3 gap-2">
            {deliveryOptions
              .find((d) => d.date === selectedDate)
              ?.timeSlots.map((slot, idx) => (
                <div
                  key={idx}
                  className={`p-2 border rounded text-center ${slot.isGreen ? "bg-green-100" : "bg-gray-50"}`}
                >
                  {slot.startTime} - {slot.endTime} {slot.isGreen && "🌿"}
                </div>
              ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default DeliveryScheduler;
