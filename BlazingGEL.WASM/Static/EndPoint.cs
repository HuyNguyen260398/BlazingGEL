﻿namespace BlazingGEL.WASM.Static;

public static class EndPoint
{
#if DEBUG
    public static string BaseUrl = "https://localhost:7057";
#else
        public static string BaseUrl = "";
#endif
    public static string PostEnpoint = $"{BaseUrl}/api/post/";
}