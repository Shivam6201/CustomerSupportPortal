import axios from 'axios';

export const lookupCustomer = async (phone) => {
  try {
    const response = await axios.get(`http://localhost:5000/api/customer/${phone}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching customer info:', error);
    return null;
  }
};
