import numpy as np
from sklearn.metrics.pairwise import cosine_similarity

# Channel-User Matrix
channel_user_matrix = [
    [1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0],  # Adventure Explorers
    [0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0],  # Food Fanatics
    [0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0],  # Fitness Enthusiasts
    [0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0],  # Tech Gurus
    [0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1],  # Fashion Finesse
    [0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1],  # Gaming Geeks
    [0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1],  # Movie Mania
    [0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0],  # Sports Fanatics
    [0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0],  # News Junkies
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1],  # Sports Zone
    [1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0],  # Culinary Delights
    [0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1],  # Fashion Trends
    [0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0],  # Tech Talk
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1],  # Movie Marathon
    [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0],  # Wanderlust
    [0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0],  # Tech Experts
    [1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],  # Fit Life
    [0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0],  # News Network
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],  # Game Central
]

# Channel data
channel_data = [
    {"channel_name": "Adventure Explorers", "genres": ["Travel", "Adventure", "Nature", "Sports"]},
    {"channel_name": "Food Fanatics", "genres": ["Food", "Cooking", "Health"]},
    {"channel_name": "Fitness Enthusiasts", "genres": ["Fitness", "Health", "Exercise", "Sports"]},
    {"channel_name": "Tech Gurus", "genres": ["Technology", "Coding"]},
    {"channel_name": "Fashion Finesse", "genres": ["Fashion", "Style", "Beauty"]},
    {"channel_name": "Gaming Geeks", "genres": ["Gaming", "Consoles", "PC", "Technology"]},
    {"channel_name": "Movie Mania", "genres": ["Movies", "TV Shows", "Entertainment"]},
    {"channel_name": "Sports Fanatics", "genres": ["Sports", "Fitness", "Health"]},
    {"channel_name": "News Junkies", "genres": ["News", "Current Affairs", "Politics"]},
    {"channel_name": "Sports Zone", "genres": ["Sports", "Fitness", "Health"]},
    {"channel_name": "Culinary Delights", "genres": ["Food", "Cooking", "Health"]},
    {"channel_name": "Fashion Trends", "genres": ["Fashion", "Style", "Beauty"]},
    {"channel_name": "Tech Talk", "genres": ["Technology", "Coding"]},
    {"channel_name": "Movie Marathon", "genres": ["Movies", "TV Shows", "Entertainment"]},
    {"channel_name": "Wanderlust", "genres": ["Travel", "Adventure", "Nature"]},
    {"channel_name": "Tech Experts", "genres": ["Technology", "Coding"]},
    {"channel_name": "Fit Life", "genres": ["Sports", "Fitness", "Health"]},
    {"channel_name": "News Network", "genres": ["News", "Current Affairs", "Politics"]},
    {"channel_name": "Game Central", "genres": ["Gaming", "Consoles", "PC"]},
]

def content_based_similarity(channel_data):
    # Collect unique genres
    unique_genres = set()
    for channel in channel_data:
        unique_genres.update(channel["genres"])

    unique_genres = list(unique_genres)  # Convert set to list for indexing

    # Create a matrix of genre vectors
    genre_matrix = np.zeros((len(channel_data), len(unique_genres)))
    for i, channel in enumerate(channel_data):
        genres = channel["genres"]
        for genre in genres:
            genre_index = unique_genres.index(genre)
            genre_matrix[i][genre_index] = 1

    # Calculate cosine similarity between genre vectors
    genre_similarity_matrix = cosine_similarity(genre_matrix)

    return genre_similarity_matrix

def collaborative_similarity(channel_user_matrix):
    num_channels = len(channel_user_matrix)
    jaccard_similarity_matrix = np.zeros((num_channels, num_channels))

    for i in range(num_channels):
        for j in range(i+1, num_channels):
            channel1_users = set(np.nonzero(channel_user_matrix[i])[0])
            channel2_users = set(np.nonzero(channel_user_matrix[j])[0])
            intersection = len(channel1_users.intersection(channel2_users))
            union = len(channel1_users.union(channel2_users))
            jaccard_similarity = intersection / union
            jaccard_similarity_matrix[i][j] = jaccard_similarity
            jaccard_similarity_matrix[j][i] = jaccard_similarity
    
    # Set diagonal elements to 1
    np.fill_diagonal(jaccard_similarity_matrix, 1)

    return jaccard_similarity_matrix

def normalize(matrix):
    min_val = np.min(matrix)
    max_val = np.max(matrix)
    normalized_matrix = (matrix - min_val) / (max_val - min_val)
    return normalized_matrix

def calculate_total_similarity(content_similarity_matrix, collaborative_similarity_matrix, weight):
    content_similarity_matrix = normalize(content_similarity_matrix)
    collaborative_similarity_matrix = normalize(collaborative_similarity_matrix)
    weighted_content_similarity = content_similarity_matrix * weight
    weighted_collaborative_similarity = collaborative_similarity_matrix * (1 - weight)
    total_similarity_matrix = weighted_content_similarity + weighted_collaborative_similarity
    return total_similarity_matrix

# Calculate content-based similarity matrix
content_similarity_matrix = cosine_similarity(channel_user_matrix)

# Calculate collaborative similarity matrix
collaborative_similarity_matrix = collaborative_similarity(channel_user_matrix)

# Set the weight for content-based similarity
weight = 0.7

# Calculate the total similarity matrix
total_similarity_matrix = calculate_total_similarity(content_similarity_matrix, collaborative_similarity_matrix, weight)

print("Total Similarity Matrix:")
print(total_similarity_matrix)

