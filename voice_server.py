from flask import Flask, request, send_file, jsonify
from flask_cors import CORS
from pydub import AudioSegment
from pydub.utils import which
import os

# Optional: Set explicit path to ffmpeg (change this if needed)
AudioSegment.converter = which("C:\\ffmpeg\\bin\\ffmpeg.exe")  # <-- Adjust path

app = Flask(__name__)
CORS(app)

@app.route('/api/convert-accent', methods=['POST'])
def convert_accent():
    if 'audio' not in request.files:
        return jsonify({"error": "No audio file provided"}), 400

    audio_file = request.files['audio']
    input_path = 'input.wav'
    output_path = 'output.wav'

    # Save incoming audio
    audio_file.save(input_path)

    try:
        # Simulate accent conversion (simple filter for now)
        sound = AudioSegment.from_file(input_path)
        converted = sound.set_frame_rate(16000).set_channels(1)
        converted.export(output_path, format='wav')

        return send_file(output_path, mimetype='audio/wav')

    except Exception as e:
        return jsonify({"error": str(e)}), 500

    finally:
        # Clean up temporary files
        if os.path.exists(input_path):
            os.remove(input_path)

# Run Flask server
if __name__ == '__main__':
    app.run(port=5001)
