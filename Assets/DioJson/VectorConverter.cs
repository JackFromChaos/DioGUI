using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

class Vector4Converter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Vector4);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JToken.Load(reader);
		if (obj.Type == JTokenType.Array)
		{
			var arr = (JArray)obj;
			
			if (arr.Count == 4 && arr.All(token => token.Type == JTokenType.Float))
			{
				return new Vector4(arr[0].Value<float>(), arr[1].Value<float>(), arr[2].Value<float>(), arr[3].Value<float>());
			}
		}
		return null;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var vector = (Vector4)value;
		writer.WriteStartArray();
		writer.WriteValue(vector.x);
		writer.WriteValue(vector.y);
		writer.WriteValue(vector.z);
		writer.WriteValue(vector.w);
		writer.WriteEndArray();
	}
}



class ColorConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Color);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JToken.Load(reader);
		if (obj.Type == JTokenType.Array)
		{
			var arr = (JArray)obj;
			if (arr.Count == 4 && arr.All(token => token.Type == JTokenType.Float))
			{
				return new Color(arr[0].Value<float>(), arr[1].Value<float>(), arr[2].Value<float>(), arr[3].Value<float>());
			}
		}
		return null;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var vector = (Color)value;
		writer.WriteStartArray();
		writer.WriteValue(vector.r);
		writer.WriteValue(vector.g);
		writer.WriteValue(vector.b);
		writer.WriteValue(vector.a);
		writer.WriteEndArray();
	}
}



class Vector3Converter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Vector3);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JToken.Load(reader);
		if (obj.Type == JTokenType.Array)
		{
			var arr = (JArray)obj;

			if (arr.Count == 3 && arr.All(token => token.Type == JTokenType.Float))
			{
				return new Vector3(arr[0].Value<float>(), arr[1].Value<float>(), arr[2].Value<float>());
			}
		}
		return null;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var vector = (Vector3)value;
		writer.WriteStartArray();
		writer.WriteValue(vector.x);
		writer.WriteValue(vector.y);
		writer.WriteValue(vector.z);
		writer.WriteEndArray();
	}
}
