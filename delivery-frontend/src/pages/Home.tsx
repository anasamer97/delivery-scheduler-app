import DeliveryScheduler from "../components/DeliveryScheduler";

const Home = () => {
  return (
    <div className="mx-auto mt-8 text-center">
      <h1 className="text-2xl font-bold mb-4">Schedule Your Delivery</h1>
      <DeliveryScheduler />
    </div>
  );
};

export default Home;
