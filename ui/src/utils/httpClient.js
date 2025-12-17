const BASE_URL =
  process.env.REACT_APP_API_BASE_URL || "http://localhost:5111/api";

export async function post(endpoint, body) {
  const response = await fetch(`${BASE_URL}${endpoint}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });

  if (!response.ok) {
    const error = await response.json();

    if (error.message) {
      throw new Error(error.message);
    }

    if (error.errors) {
      const firstField = Object.keys(error.errors)[0];
      const firstMessage = error.errors[firstField][0];
      throw new Error(firstMessage);
    }

    throw new Error("Something went wrong");
  }

  return response.json();
}
